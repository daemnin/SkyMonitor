#include "SkyMonitor.h"

void print_packet(HardwareSerial* hwSerial, packet_t* packet) {
  packet_t pkt = *packet;
  hwSerial->print(pkt.device.location.latitude, 6); hwSerial->print(", "); hwSerial->println(pkt.device.location.longitude, 6);
  for(int index = 0; index < 12; index++) {
    hwSerial->println(pkt.bytes[index], DEC);
  } 
  hwSerial->println();
}

void send_packet(packet_t* packet) {
  
}
