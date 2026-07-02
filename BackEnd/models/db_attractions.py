from db.init_db import Base
from sqlalchemy.orm import Mapped, mapped_column
from sqlalchemy import String, DateTime, ForeignKey
import datetime


class DBAttractions(Base):
    __tablename__ = "Attractions"

    id: Mapped[int] = mapped_column(primary_key=True, unique=True)
    name: Mapped[str] = mapped_column(String(100), unique=True)
    adrress: Mapped[str] = mapped_column(String(1000))
    area_id: Mapped[int] = mapped_column(ForeignKey("Areas.id"))
