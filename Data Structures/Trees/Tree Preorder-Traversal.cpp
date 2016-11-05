/*
HackerRank - DataStructures - Trees - Preorder Traversal
Link: https://www.hackerrank.com/challenges/tree-preorder-traversal
*/

/*
you only have to complete the function given below.
Node is defined as

struct node
{
int data;
node* left;
node* right;
};

*/

void preOrder(node* root) {

	// Output with space
	std::cout << root->data << " ";

	// Tranverse left first (preorder)
	if (root->left) { preOrder(root->left); }
	if (root->right) { preOrder(root->right); }
}