from sqlalchemy import create_engine
from sqlalchemy.orm import sessionmaker, DeclarativeBase
from db.init_db import SessionLocal


def get_db():
    db = SessionLocal()
    try:
        yield db
    finally:
        db.close
