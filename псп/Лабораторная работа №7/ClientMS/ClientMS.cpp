#include <iostream>
#include <clocale>
#include <ctime>

#include "ErrorMsgText.h"
#include "Windows.h"

#define NAME L"\\\\*\\mailslot\\Box"
#define STOP "STOP"


const wchar_t* MAILSLOT_NAMES[] = {
    L"\\\\.\\mailslot\\Box",
    L"\\\\stanislaw\\mailslot\\Box",
};

const int NUM_SERVERS = 2;

using namespace std;

int main()
{
    setlocale(LC_ALL, "rus");

    HANDLE cM;
    DWORD rb;
    clock_t start, end;
    char wbuf[300] = "Hello from Maislot-client";

    try {
        cout << "ClientMS\n\n";
        int countMessage;
        cout << "Number of messages: ";
        cin >> countMessage;
        for (int j = 0; j < NUM_SERVERS; j++) {
            // cout << MAILSLOT_NAMES[j];
            if ((cM = CreateFile(MAILSLOT_NAMES[j], GENERIC_WRITE, FILE_SHARE_READ,
                NULL, OPEN_EXISTING, NULL, NULL)) == INVALID_HANDLE_VALUE) {
                throw SetPipeError("CreateFile: ", GetLastError());
            }



            for (int i = 1; i <= countMessage; i++) {
                if (i) {
                    start = clock();
                }

                if (!WriteFile(cM, wbuf, sizeof(wbuf), &rb, NULL)) {
                    throw SetPipeError("WriteFile: ", GetLastError());
                }

                cout << wbuf << endl;
            }

            if (!WriteFile(cM, STOP, sizeof(STOP), &rb, NULL)) {
                throw SetPipeError("WriteFile: ", GetLastError());
            }

            end = clock();
            cout << "Time for send and recv: " << ((double)(end - start) / CLK_TCK) << " c" << endl;


            if (!CloseHandle(cM)) {
                throw SetPipeError("CloseHandle: ", GetLastError());
            }
        }
        system("pause");
    }
    catch (string ErrorPipeText) {
        cout << endl << ErrorPipeText;
    }
}