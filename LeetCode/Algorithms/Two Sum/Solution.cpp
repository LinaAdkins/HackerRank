class Solution {
public:
	vector<int> twoSum(vector<int>& nums, int target) {
		auto indices = unordered_map<int, int>();

		// Single Pass
		for (int i = 0; i < nums.size(); i++) {
			int complement = target - nums[i];

			// If we have the complement, we've got our result!
			if (indices.find(complement) != indices.end()) {
				vector<int> result = { indices[complement] , i };
				return result;
			}

			// Add current index to our hashmap
			indices[nums[i]] = i;
		}

		throw runtime_error("No solution!");

	}
};