from pydantic import BaseModel
from datetime import datetime


class UserRegister(BaseModel):

    username: str
    password: str
    fullname: str
    gender: str
    birthdate: datetime
    family_count: int
