#include <stdio.h>
#include <stdlib.h>
#include <stdbool.h> 
#include <math.h>

int fc(int);
float mysin(float x,int n,int maxn);

int main()
{
   // printf("result = %f",mysin(0.8,1,4));

    float E = 0.0001;
    float X = 1.2345;
    float y = 0;

    int n = 1;

    //printf("result = %f N = %i ",mysin(X,1,n),n);

    do
    {
        printf("ERR = %f N = %i\n",fabs( sinf(X) - mysin(X,1,n)) ,n);
        n ++;
    }  while(fabs( sinf(X) - mysin(X,1,n)) > E);

    return 0;
}


float mysin(float x,int n,int maxn)
{
    if(n > maxn) return 0;
    return pow(-1,n - 1) * ( pow(x,2*n - 1)/fc(2*n - 1) ) + mysin(x,n+1,maxn);
}

int fc(int x)
{
    if(x <= 0) return 1;
    else return x*fc(x-1);
}