#include "SkyMonitor.h"

void print_packet(HardwareSerial* hwSerial, packet_t* packet) {
  packet_t pkt = *packet;
  hwSerial->print(pkt.location.latitude, 6); hwSerial->print(", "); hwSerial->println(pkt.location.latitude, 6);
  for(int index = 0; index < 8; index++) {
    hwSerial->println(pkt.bytes[index], HEX);
  } 
  hwSerial->println();
}

void send_packet(packet_t* packet) {
  
}
