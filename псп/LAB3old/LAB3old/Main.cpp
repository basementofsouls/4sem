#pragma comment(lib, "WS2_32.lib") 
#pragma warning(disable: 4996)
#include "Winsock2.h"

#include <algorithm>
#include <iostream>
#include <string>
#include <chrono>
#define MESSAGENUM 100

using namespace std;

string SetErrorMsgText(string msgText, int code);
string GetErrorMsgText(int code);


void main() {
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);

	SOCKET sS;
	WSADATA wsaData;

	try
	{
		//...........................................................
		if (WSAStartup(MAKEWORD(2, 0), &wsaData) != 0)
			throw  SetErrorMsgText("Startup:", WSAGetLastError());

		if ((sS = socket(AF_INET, SOCK_DGRAM, NULL)) == INVALID_SOCKET)
			throw  SetErrorMsgText("socket:", WSAGetLastError());
		/////////////////////////////////////////////////////////////

		SOCKADDR_IN serv;
		serv.sin_family = AF_INET;
		serv.sin_port = htons(2000);
		serv.sin_addr.s_addr = INADDR_ANY/*inet_addr("192.168.0.100")*/; //127.0.0.1

		if (bind(sS, (SOCKADDR*)&serv, sizeof(serv)) == SOCKET_ERROR)
			throw  SetErrorMsgText("bind:", WSAGetLastError());

		SOCKADDR_IN clientU;

		const int SIZE = 512;
		char buffer[SIZE];
		string msg;
		auto start = chrono::high_resolution_clock::now();
		int cnt = 0;
		int i = 0;
		bool flag = true;
		int clientlen = (int)sizeof(clientU);
		while (flag) {
			if (recvfrom(sS, buffer, SIZE, NULL, (SOCKADDR*)&clientU, &clientlen) == SOCKET_ERROR) {
				break;
			}
			Sleep(10);
			cnt++;
			std::cout << "������ �������: " << buffer << endl;
			string msg = buffer;
			if (msg[0] == ' ') break;
			msg.replace(msg.find("client"), msg.find("client") + 6, "server");
			cout << "������ ��������: "<<msg<<endl;
			msg.copy(buffer, SIZE);
			if (sendto(sS, buffer, strlen(buffer) + 1, NULL, (SOCKADDR*)&clientU, clientlen) == SOCKET_ERROR) {
				throw  SetErrorMsgText("Cleanup:", WSAGetLastError());
			}
		}

		cout << "������ �������: " << cnt;
		auto stop = chrono::high_resolution_clock::now();
		auto duration = chrono::duration_cast<chrono::milliseconds>(stop - start);

		cout << "\n����� ���������� �����: " << duration.count() << " ��" << endl;
		if (closesocket(sS) == SOCKET_ERROR)
			throw  SetErrorMsgText("closesocket:", WSAGetLastError());

		if (WSACleanup() == SOCKET_ERROR)
			throw  SetErrorMsgText("Cleanup:", WSAGetLastError());
	}
	catch (string errorMsgText)
	{
		std::cout << endl << "WSAGetLastError: " << errorMsgText;
	}

}


string  SetErrorMsgText(string msgText, int code)
{
	return  msgText + GetErrorMsgText(code);
}

string  GetErrorMsgText(int code)    // c����������� ����� ������ 
{

	string msgText;
	switch (code)
	{
	case WSAEINTR:				 msgText = "������ ������� ��������\n";						  break;
	case WSAEACCES:				 msgText = "���������� ����������\n";						  break;
	case WSAEFAULT:				 msgText = "��������� �����\n";								  break;
	case WSAEINVAL:				 msgText = "������ � ���������\n";							  break;
	case WSAEMFILE:				 msgText = "������� ����� ������ �������\n";				  break;
	case WSAEWOULDBLOCK:		 msgText = "������ �������� ����������\n";					  break;
	case WSAEINPROGRESS:		 msgText = "�������� � �������� ��������\n";				  break;
	case WSAEALREADY: 			 msgText = "�������� ��� �����������\n";					  break;
	case WSAENOTSOCK:   		 msgText = "����� ����� �����������\n";						  break;
	case WSAEDESTADDRREQ:		 msgText = "��������� ����� ������������\n";				  break;
	case WSAEMSGSIZE:  			 msgText = "��������� ������� �������\n";				      break;
	case WSAEPROTOTYPE:			 msgText = "������������ ��� ��������� ��� ������\n";		  break;
	case WSAENOPROTOOPT:		 msgText = "������ � ����� ���������\n";					  break;
	case WSAEPROTONOSUPPORT:	 msgText = "�������� �� ��������������\n";					  break;
	case WSAESOCKTNOSUPPORT:	 msgText = "��� ������ �� ��������������\n";				  break;
	case WSAEOPNOTSUPP:			 msgText = "�������� �� ��������������\n";					  break;
	case WSAEPFNOSUPPORT:		 msgText = "��� ���������� �� ��������������\n";			  break;
	case WSAEAFNOSUPPORT:		 msgText = "��� ������� �� �������������� ����������\n";	  break;
	case WSAEADDRINUSE:			 msgText = "����� ��� ������������\n";						  break;
	case WSAEADDRNOTAVAIL:		 msgText = "����������� ����� �� ����� ���� �����������\n";	  break;
	case WSAENETDOWN:			 msgText = "���� ���������\n";								  break;
	case WSAENETUNREACH:		 msgText = "���� �� ���������\n";							  break;
	case WSAENETRESET:			 msgText = "���� ��������� ����������\n";					  break;
	case WSAECONNABORTED:		 msgText = "����������� ����� �����\n";						  break;
	case WSAECONNRESET:			 msgText = "����� �������������\n";							  break;
	case WSAENOBUFS:			 msgText = "�� ������� ������ ��� �������\n";				  break;
	case WSAEISCONN:			 msgText = "����� ��� ���������\n";							  break;
	case WSAENOTCONN:			 msgText = "����� �� ���������\n";							  break;
	case WSAESHUTDOWN:			 msgText = "������ ��������� send: ����� �������� ������\n";  break;
	case WSAETIMEDOUT:			 msgText = "���������� ���������� ��������  �������\n";		  break;
	case WSAECONNREFUSED:		 msgText = "���������� ���������\n";						  break;
	case WSAEHOSTDOWN:			 msgText = "���� � ����������������� ���������\n";			  break;
	case WSAEHOSTUNREACH:		 msgText = "��� �������� ��� �����\n";						  break;
	case WSAEPROCLIM:			 msgText = "������� ����� ���������\n";						  break;
	case WSASYSNOTREADY:		 msgText = "���� �� ��������\n";							  break;
	case WSAVERNOTSUPPORTED:	 msgText = "������ ������ ����������\n";					  break;
	case WSANOTINITIALISED:		 msgText = "�� ��������� ������������� WS2_32.DLL\n";		  break;
	case WSAEDISCON:			 msgText = "����������� ����������\n";						  break;
	case WSATYPE_NOT_FOUND:		 msgText = "����� �� ������\n";								  break;
	case WSAHOST_NOT_FOUND:		 msgText = "���� �� ������\n";								  break;
	case WSAEINVALIDPROCTABLE:	 msgText = "��������� ������\n";							  break;
	case WSAEINVALIDPROVIDER:	 msgText = "������ � ������ �������\n";						  break;
	case WSAEPROVIDERFAILEDINIT: msgText = "���������� ���������������� ������\n";			  break;
	case WSASYSCALLFAILURE:		 msgText = "��������� ���������� ���������� ������\n";		  break;
	case WSATRY_AGAIN:			 msgText = "������������������ ���� �� ������\n";			  break;
	case WSANO_RECOVERY:		 msgText = "�������������� ������\n";						  break;
	case WSANO_DATA:			 msgText = "��� ������ ������������ ����\n";				  break;
	default:					 msgText = "������ �� ����������\n";						  break;
	}

	return msgText;
}