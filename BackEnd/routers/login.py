from fastapi import APIRouter, Depends
from schemas.user_login import UserLogin
from schemas.user_register import UserRegister
from security.user_auth import UserAuth
from db.get_db import get_db
from sqlalchemy.orm import Session
from models.db_users import DBUSer

router = APIRouter(prefix="/seoul/v1")
user_auth = UserAuth()


@router.post("/login")
async def login(user: UserLogin):
    token = user_auth.login_for_access_token(user.username, user.password)
    print(f"access token : {token.access_token}")
    return token


@router.post("/register")
async def register(user: UserRegister, db: Session = Depends(get_db)):
    db_user = DBUSer(
        username=user.username,
        password=user.password,
        fullname=user.fullname,
        gender=user.gender,
        birthdate=user.birthdate,
        family_count=user.family_count,
    )
    db.add(db_user)
    db.commit()
    db.refresh(db_user)
    token = user_auth.login_for_access_token(user.username, user.password)
    print(f"access token : {token.access_token}")
    return token
