import requests
import datetime
from config import tg_bot_token, open_weather_token
from aiogram import Bot, types
from aiogram.dispatcher import Dispatcher
from aiogram.utils import executor

bot = Bot(token=tg_bot_token)
dp = Dispatcher(bot)

@dp.message_handler(commands=["start"])
async def start_command(message: types.Message):
    await message.reply("Погоду в каком городе ты хочешь узнать?) Только пиши на английском, пожалуйста)))")

@dp.message_handler()
async def get_weather(message: types.Message):
    try:
        r = requests.get(
            f"http://api.openweathermap.org/data/2.5/weather?q={message.text}&appid={open_weather_token}&units=metric"
        )
        data = r.json()

        city = data["name"]
        cur_weather = data["main"]["temp"]
        humidity = data["main"]["humidity"]
        pressure = data["main"]["pressure"]
        wind = data["wind"]["speed"]
        sunrise_timestamp = datetime.datetime.fromtimestamp(data["sys"]["sunrise"])
        sunset_timestamp = datetime.datetime.fromtimestamp(data["sys"]["sunset"])

        await message.reply(f"Погода в городе: {city} на {datetime.datetime.now().strftime('%d-%m-%Y')}\n"
              f"Температура: {cur_weather} С\n"
              f"Влажность: {humidity} %\n"
              f"Давление: {pressure} мм.рт.ст\n"
              f"Скорость ветра: {wind} м/с\n"
              f"Время рассвета: {sunrise_timestamp}\n"
              f"Время заката: {sunset_timestamp}")

    except:
        await message.reply("Проверьте название города")


if __name__ == '__main__':
    executor.start_polling(dp)