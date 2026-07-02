from db.init_db import Base
from sqlalchemy.orm import Mapped, mapped_column
from sqlalchemy import String, DateTime, ForeignKey
import datetime


class DBAreas(Base):
    __tablename__ = "Areas"

    id: Mapped[int] = mapped_column(primary_key=True, unique=True)
    name: Mapped[str] = mapped_column(String(100), unique=True)
