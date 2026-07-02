from db.init_db import Base
from sqlalchemy.orm import Mapped, mapped_column
from sqlalchemy import String


class DBUser_Types(Base):
    __tablename__ = "UserTypes"

    id: Mapped[int] = mapped_column(primary_key=True, unique=True)
    name: Mapped[str] = mapped_column(String(100), unique=True)
