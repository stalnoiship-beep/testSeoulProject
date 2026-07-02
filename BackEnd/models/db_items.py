from db.init_db import Base
from sqlalchemy.orm import Mapped, mapped_column
from sqlalchemy import String, DateTime, ForeignKey
import datetime


class DBItems(Base):
    __tablename__ = "Items"

    id: Mapped[int] = mapped_column(primary_key=True, unique=True)
    user_id: Mapped[int] = mapped_column(ForeignKey("Users.id"))
    item_type_id: Mapped[int] = mapped_column(ForeignKey("ItemTypes.id"))
    area_id: Mapped[int] = mapped_column(ForeignKey("Areas.id"))
    title: Mapped[str] = mapped_column()
    capacity: Mapped[int] = mapped_column()
    number_of_beds: Mapped[int] = mapped_column()
    number_of_bedrooms: Mapped[int] = mapped_column()
    exact_adress: Mapped[str] = mapped_column()
    approximates_address: Mapped[str] = mapped_column()
    description: Mapped[str] = mapped_column()
    host_rules: Mapped[str] = mapped_column()
    min_nights: Mapped[int] = mapped_column()
    max_nights: Mapped[int] = mapped_column()
