



Requirements:

Search should be case-insensitive

Search and wildcards:

	* "*al" should match "pal" and "artisinal" but not "wall"
	* "al*" should match "alter" and "all" but not "fall"
	* "*al*" should match "pal", "fall", "alter"
	* There should be unit tests for all three scenarios.

When you first get to the dictionary page, the results say "No entries found matching the criteria." Instead, it should show nothing. So there's three cases.

	* When you first get there, nothing should appear below the search box.
	* If you search and find something, it should show
	* If you search and find nothing, you should show the existing message: "No entries found matching the criteria."
