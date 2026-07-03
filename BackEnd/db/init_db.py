from sqlalchemy.orm import sessionmaker, DeclarativeBase
from sqlalchemy import create_engine

DATABASE_URL = "postgresql://postgres:123@test_db:5432/test_db"
engine = create_engine(DATABASE_URL, echo=True)
SessionLocal = sessionmaker(autoflush=False, autocommit=False, bind=engine)


class Base(DeclarativeBase):
    pass
