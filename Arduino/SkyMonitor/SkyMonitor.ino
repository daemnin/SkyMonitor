#include "SkyMonitor.h"

packet_t pkt;
location_t *location = &pkt.device.location;

GSMClient client;
GPRS gprs;
GSM gsmAccess;

AltSoftSerial  gpsSignal; // recibimos señal de gps, puerto 5 RX y puerto 4 TX
TinyGPS gps;

void setup()
{
  Serial.begin(SS_BAUD_RATE);
  gpsSignal.begin(SS_BAUD_RATE); //cambiamos la velocidad de lectura del puerto serie emulando a 9600 baudios
  pkt.device.id = DEVICE_ID;
  
  while (!(gsmAccess.begin(PINNUMBER) == GSM_READY && gprs.attachGPRS(GPRS_APN, GPRS_LOGIN, GPRS_PASSWORD) == GPRS_READY)){
    Serial.println("???");
    delay(1000);
  }
  Serial.println(VERSION);
}


void loop()
{
  if (gpsSignal.available())
  {
    if (gps.encode(gpsSignal.read())) // encode gps data
    {
      Serial.println("Reading GPS...");
      gps.f_get_position(&(location->latitude), &(location->longitude));
      if (location->latitude == TinyGPS::GPS_INVALID_F_ANGLE ||
          location->longitude == TinyGPS::GPS_INVALID_F_ANGLE) return;
      //print_packet(&Serial, &pkt);
      send_packet(&Serial, &client, &pkt);
    }
  }
}


