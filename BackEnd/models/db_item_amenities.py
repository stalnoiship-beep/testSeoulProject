from db.init_db import Base
from sqlalchemy.orm import Mapped, mapped_column
from sqlalchemy import String, DateTime, ForeignKey
import datetime


class DBItemAmenities(Base):
    __tablename__ = "ItemAmenities"

    id: Mapped[int] = mapped_column(primary_key=True, unique=True)
    item_id: Mapped[int] = mapped_column(ForeignKey("Items.id"))
    amenity_id: Mapped[int] = mapped_column(ForeignKey("Amenities.id"))
