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
            V,   // [in]  максимальный вес груза
            MM,  // [in]  количество мест для контейнеров     
            K,  // [in]  всего контейнеров  
            v,   // [in]  вес каждого контейнера  
            c,   // [in]  доход от перевозки каждого контейнера     
            r    // [out] результат: индексы выбранных контейнеров  
        );
        t1 = clock();
        std::cout << std::endl << "- Задача о размещении контейнеров на судне";
        std::cout << std::endl << "- общее количество контейнеров    : " << NN;
        std::cout << std::endl << "- количество мест для контейнеров : " << MM;
        std::cout << std::endl << "- ограничение по суммарному весу  : " << V;
        std::cout << std::endl << "- вес контейнеров                 : ";
        for (int i = 0; i < NN; i++) std::cout << std::setw(3) << v[i] << " ";
        std::cout << std::endl << "- доход от перевозки              : ";
        for (int i = 0; i < NN; i++) std::cout << std::setw(3) << c[i] << " ";
        std::cout << std::endl << "- выбраны контейнеры (0,1,...,m-1): ";
        for (int i = 0; i < MM; i++) std::cout << r[i] << " ";
        std::cout << std::endl << "- доход от перевозки              : " << cc;
        std::cout << std::endl << "- общий вес выбранных контейнеров : ";
        int s = 0; for (int i = 0; i < MM; i++) s += v[r[i]]; std::cout << s;
        std::cout << std::endl << std::endl;
        t2 = clock();
        std::cout << std::endl << "продолжительность (у.е):   " << (t2 - t1);
        std::cout << std::endl << std::endl;
        system("pause");
        return 0;
    }
