// ConsoleCtest.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"

struct st_test {
	int i;
	float f;
	double d;
};

int main()
{
	int n[20];
	double *pd;

	pd = (double *)(n + 2);
	*pd = 2.2;
	n[0] = 0;
	n[1] = 1;
	n[2] = 3;
	n[4] = 5;
	struct st_test *pst;

	pst = (struct st_test*)n;
	printf(" c test struct , %d %.2f\n",pst->i,pst->d);
    return 0;
}

