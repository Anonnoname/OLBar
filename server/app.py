from flask import Flask
import json

app = Flask(__name__)

@app.route('/')
def hello_world():
    return "Hello World"

@app.route("/add", methods=["POST"])
def add():
    """
        add new player.    
    """
    return "Login Test"


if __name__ == '__main__':
    app.run()