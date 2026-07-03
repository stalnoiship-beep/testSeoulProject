from db.init_db import Base
from db.init_db import engine
from fastapi import FastAPI
from routers import login
import db.defalut_data
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
db.defalut_data.add_default_user_types()

app = FastAPI()
app.include_router(login.router)
