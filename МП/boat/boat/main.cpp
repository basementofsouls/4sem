#include <iostream>
#include <iomanip>
#include "Header.h"
#define NN (sizeof(v)/sizeof(int))
#define MM 6
#define K 25

int main()
    {
        setlocale(LC_ALL, "rus");
        int V = 1500,
            v[K],
            c[K];
        short  r[MM];
        clock_t  t1 = 0, t2 = 0;
        srand(unsigned(time(NULL)));
        for (int i = 0; i < K; i++) {
            v[i] = rand() % 900 + 100;
        }
        for (int i = 0; i < K; i++) {
            c[i] = rand() % 150 + 10;
        }
        int cc = boat(
            V,   // [in]  ������������ ��� �����
            MM,  // [in]  ���������� ���� ��� �����������     
            K,  // [in]  ����� �����������  
            v,   // [in]  ��� ������� ����������  
            c,   // [in]  ����� �� ��������� ������� ����������     
            r    // [out] ���������: ������� ��������� �����������  
        );
        t1 = clock();
        std::cout << std::endl << "- ������ � ���������� ����������� �� �����";
        std::cout << std::endl << "- ����� ���������� �����������    : " << NN;
        std::cout << std::endl << "- ���������� ���� ��� ����������� : " << MM;
        std::cout << std::endl << "- ����������� �� ���������� ����  : " << V;
        std::cout << std::endl << "- ��� �����������                 : ";
        for (int i = 0; i < NN; i++) std::cout << std::setw(3) << v[i] << " ";
        std::cout << std::endl << "- ����� �� ���������              : ";
        for (int i = 0; i < NN; i++) std::cout << std::setw(3) << c[i] << " ";
        std::cout << std::endl << "- ������� ���������� (0,1,...,m-1): ";
        for (int i = 0; i < MM; i++) std::cout << r[i] << " ";
        std::cout << std::endl << "- ����� �� ���������              : " << cc;
        std::cout << std::endl << "- ����� ��� ��������� ����������� : ";
        int s = 0; for (int i = 0; i < MM; i++) s += v[r[i]]; std::cout << s;
        std::cout << std::endl << std::endl;
        t2 = clock();
        std::cout << std::endl << "����������������� (�.�):   " << (t2 - t1);
        std::cout << std::endl << std::endl;
        system("pause");
        return 0;
    }
