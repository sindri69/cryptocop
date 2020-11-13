FROM python:3

WORKDIR /app


RUN pip install requests pika

COPY . .

CMD [ "python", "email_service.py" ]