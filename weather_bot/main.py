import requests
import datetime
from pprint import pprint
from config import open_weather_token

def get_weather(city, open_weather_token):
    try:
        r = requests.get(
            f"http://api.openweathermap.org/data/2.5/weather?q={city}&appid={open_weather_token}&units=metric"
        )
        data = r.json()
        #pprint(data)

        city = data["name"]
        cur_weather = data["main"]["temp"]
        humidity = data["main"]["humidity"]
        pressure = data["main"]["pressure"]
        wind = data["wind"]["speed"]
        sunrise_timestamp = datetime.datetime.fromtimestamp(data["sys"]["sunrise"])
        sunset_timestamp = datetime.datetime.fromtimestamp(data["sys"]["sunset"])

        print(f"Погода в городе: {city} на {datetime.datetime.now().strftime('%d-%m-%Y')}\n"
              f"Температура: {cur_weather} С\n"
              f"Влажность: {humidity} %\n"
              f"Давление: {pressure} мм.рт.ст\n"
              f"Скорость ветра: {wind} м/с\n"
              f"Время рассвета: {sunrise_timestamp}\n"
              f"Время заката: {sunset_timestamp}")

    except Exception as ex:
        print(ex)
        print("Проверьте название города")

def main():
    city = input("Введите город: ")
    get_weather(city, open_weather_token)

if __name__ == '__main__':
    main()