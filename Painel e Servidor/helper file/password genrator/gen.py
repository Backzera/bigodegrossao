import random
import string

def generate_admin_key():
    segments = ["".join(random.choices(string.ascii_uppercase + string.digits, k=4)) for _ in range(4)]
    return "-".join(segments)

def generate_mysql_password(length=16):
    characters = string.ascii_letters + string.digits
    return "".join(random.choices(characters, k=length))


print("MySQL Password:", generate_mysql_password())
print("Admin Key:", generate_admin_key())