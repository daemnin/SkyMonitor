#include "SkyMonitor.h"

void print_packet(HardwareSerial* hwSerial, packet_t* packet) {
  hwSerial->print(packet->device.location.latitude, 6); hwSerial->print(", "); hwSerial->println(packet->device.location.longitude, 6);
  for(int index = 0; index < PACKAGE_BUFFER_SIZE; index++) {
    hwSerial->println(packet->bytes[index], HEX);
  } 
  hwSerial->println();
}

void send_packet(HardwareSerial* hwSerial, GSMClient* client, packet_t* packet) {
  hwSerial->println("Enviando posicion");
  if (client->connect(API_SERVER, API_PORT))
  {
    client->println("POST /SkyMonitor.API/api/location HTTP/1.1");
    client->println("Host: daemnin.dlinkddns.com");
    client->println("Cache-Control: no-cache");
    client->println("Connection: close");
    client->println("Content-Length: 12");
    client->println();
    client->write(packet->bytes, PACKAGE_BUFFER_SIZE);
    client->stop();
    hwSerial->println("Posición enviada");
  }
  else
  {
    hwSerial->println("No se pudo enviar datos");
  }
}
