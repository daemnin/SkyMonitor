#include <SoftwareSerial.h>
#include <TinyGPS.h>
#include "SkyMonitor.h"

packet_t pkt;
location_t *location = &pkt.location;

SoftwareSerial gpsSignal(GPS_RX, GPS_TX); // recibimos señal de gps, puerto 5 RX y puerto 4 TX
TinyGPS gps;

void setup()
{
  Serial.begin(SERIAL_BAUD_RATE);
  gpsSignal.begin(SS_BAUD_RATE); //cambiamos la velocidad de lectura del puerto serie emulando a 9600 baudios
  Serial.println(VERSION);
}


void loop()
{
  if (gpsSignal.available())
  {
    Serial.println("GPS available...");
    if (gps.encode(gpsSignal.read())) // encode gps data
    {
      Serial.println("Reading GPS...");
      gps.f_get_position(&(location->latitude), &(location->longitude));
      print_packet(&Serial, &pkt);
      send_packet(&pkt);
    }
  }
}


