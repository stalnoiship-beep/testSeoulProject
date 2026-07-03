from datetime import timedelta, datetime
import jwt
import settings
from models.db_users import DBUSer
from fastapi import HTTPException
from schemas.token import Token
from db.init_db import SessionLocal


class UserAuth:
    def __select_user_by_login(self, login):
        db = SessionLocal()
        db_user: DBUSer = db.query(DBUSer).filter(DBUSer.username == login).first()
        if db_user:
            return db_user
        return None

    def create_access_token(self, data: dict, expires_delta: timedelta):
        to_encode = data.copy()
        expire = datetime.now() + expires_delta
        to_encode.update({"exp": expire})
        encoded_jwt = jwt.encode(to_encode, settings.SECRET_KEY, algorithm="HS256")
        return encoded_jwt

    def validate_user(self, login: str, password: str) -> Token:
        user: DBUSer = self.__select_user_by_login(login)
        if user and user.password == password:
            return user
        else:
            return False

    def login_for_access_token(self, login: str, password: str) -> Token:
        user: DBUSer = self.validate_user(login, password)

        if not user:
            raise HTTPException(
                status_code=401, detail="Incorrect username or password"
            )

        access_token_lifetime = timedelta(minutes=60)
        access_token = self.create_access_token(
            data={"login": user.username, "password": user.password},
            expires_delta=access_token_lifetime,
        )
        return Token(
            access_token=access_token,
            token_type="bearer",
            access_token_expires=str(access_token_lifetime),
        )

    def get_current_user(self, token: str):
        exception = HTTPException(status_code=401, detail="Ничего не работает")
        try:
            payload = jwt.decode(
                token, settings.SECRET_KEY, algorithms=[settings.ALGORITHM]
            )

            login = payload.get("login")
            password = payload.get("password")
            exp = payload.get("exp")

            if not login:
                raise exception
            if datetime.fromtimestamp(float(exp)) - datetime.now() < timedelta(0):
                raise Exception
        except jwt.InvalidTokenError:
            raise exception
        user: DBUSer = self.validate_user(login, password)

        if user is None:
            raise exception
        return user
