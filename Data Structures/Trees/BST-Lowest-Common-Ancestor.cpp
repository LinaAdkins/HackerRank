/*
HackerRank - DataStructures - BST - Lowest Common Ancestor
Link: https://www.hackerrank.com/challenges/binary-search-tree-lowest-common-ancestor

Node is defined as

typedef struct node
{
int data;
node * left;
node * right;
}node;

*/


node * lca(node * root, int v1, int v2)
{
	// Tree splits here!
	if ((v1 > root->data && v2 < root->data) || (v1 < root->data && v2 > root->data)) {
		return root;
	}

	// Weird case, but keeps recursion from failing
	if (v1 == v2) { return root; }

	// Smaller, go left!
	if (v1 < root->data) {
		return lca(root->left, v1, v2);
	}

	// Bigger, go right!
	if (v1 > root->data) {
		return lca(root->right, v1, v2);
	}

	// RETURN: If we fall through completely, just return!
	return root;

}