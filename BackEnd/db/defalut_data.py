from db.init_db import SessionLocal
from models.db_usertypes import DBUser_Types


def add_default_user_types():
    db = SessionLocal()
    admin_type = DBUser_Types(name="admin")
    user_type = DBUser_Types(name="user")
    db.add(user_type)
    db.add(admin_type)
    db.commit()
