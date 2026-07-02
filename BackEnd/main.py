from db.init_db import Base
from db.init_db import engine
from models import (
    db_areas,
    db_amenities,
    db_attractions,
    db_item_amenities,
    db_item_types,
    db_items,
    db_users,
    db_usertypes,
)

Base.metadata.create_all(bind=engine)
