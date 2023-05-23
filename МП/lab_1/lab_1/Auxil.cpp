#include "Auxil.h" 
#include <ctime>    
namespace auxil
{
    void start()                          // старт  генератора сл. чисел
    {
        srand((unsigned)time(NULL));
    };
    double dget(double rmin, double rmax) // функция возвращает действительное псевдослучайное число в диапазоне оn rmin до rmax
    {
        return ((double)rand() / (double)RAND_MAX) * (rmax - rmin) + rmin;
    };
    int iget(int rmin, int rmax)         // функция возвращает целое псевдослучайное число в диапазоне оn rmin до  rmax
    {
        return (int)dget((double)rmin, (double)rmax);
    };
}
