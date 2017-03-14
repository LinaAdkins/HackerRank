#include <math.h>
#include <stdio.h>
#include <string.h>
#include <stdlib.h>
#include <assert.h>
#include <limits.h>
#include <stdbool.h>

int main() {
	int n;
	int t;
	scanf("%d %d", &n, &t);
	int *c = malloc(sizeof(int) * t);

	int currCandy = n;
	int totalRefill = 0;
	for (int c_i = 0; c_i < t; c_i++) {
		scanf("%d", &c[c_i]);

		currCandy = currCandy - c[c_i];

		// Refill if lower than 5 and not end of party
		if (currCandy < 5 && c_i != t - 1) {
			totalRefill += n - currCandy;
			currCandy = n;
		}

	}

	printf("%d", totalRefill);
	// your code goes here
	return 0;
}