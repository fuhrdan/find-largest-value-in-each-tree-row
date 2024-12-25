//*****************************************************************************
//** 515. Find Largest Value in Each Tree Row                       leetcode **
//*****************************************************************************

/**
 * Definition for a binary tree node.
 * struct TreeNode {
 *     int val;
 *     struct TreeNode *left;
 *     struct TreeNode *right;
 * };
 */
/**
 * Note: The returned array must be malloced, assume caller calls free().
 */
void dfs(struct TreeNode* root, int curr, int** ans, int* size) {
    if (root == NULL) {
        return;
    }

    if (curr == *size) {
        *size += 1;
        *ans = realloc(*ans, (*size) * sizeof(int));
        (*ans)[curr] = root->val; 
    } else {
        (*ans)[curr] = (*ans)[curr] > root->val ? (*ans)[curr] : root->val;
    }

    dfs(root->left, curr + 1, ans, size);
    dfs(root->right, curr + 1, ans, size);
}

int* largestValues(struct TreeNode* root, int* returnSize) {
    *returnSize = 0;
    int* ans = NULL;

    dfs(root, 0, &ans, returnSize);

    return ans;
}