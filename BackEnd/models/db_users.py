from db.init_db import Base
from sqlalchemy.orm import Mapped, mapped_column, relationship
from sqlalchemy import String, DateTime, ForeignKey
from models.db_usertypes import DBUser_Types
import datetime


class DBUSer(Base):
    __tablename__ = "Users"

    id: Mapped[int] = mapped_column(primary_key=True, unique=True)
    username: Mapped[str] = mapped_column(String(100), unique=True)
    password: Mapped[str] = mapped_column(String(1000))
    fullname: Mapped[str] = mapped_column(String(1000))
    gender: Mapped[str] = mapped_column(String(10))
    birthdate: Mapped[datetime.datetime] = mapped_column(DateTime())
    family_count: Mapped[int] = mapped_column()
    user_type_id: Mapped[int] = mapped_column(ForeignKey("UserTypes.id"), default=1)
    user_type: Mapped[DBUser_Types] = relationship()
