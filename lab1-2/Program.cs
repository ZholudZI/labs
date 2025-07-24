void bubbleSort(List<int> list)
{
	for (int j = 0; j < list.Count - 1; j++)
	{
		for (int i = 0; i < list.Count - 1; i++)
		{
			if (list[i] > list[i + 1])
			{
				int temp = list[i];
				list[i] = list[i + 1];
				list[i + 1] = temp;
			}
		}
	}
}

void optimizeBubbleSort(List<int> list)
{
	bool isSorted = false;
	for (int j = 0; j < list.Count - 1 && !isSorted; j++)
	{
		isSorted = true;
		for (int i = 0; i < list.Count - 1; i++)
		{
			if (list[i] > list[i + 1])
			{
				isSorted = false;
				int temp = list[i];
				list[i] = list[i + 1];
				list[i + 1] = temp;
			}
		}
	}
}

void printList(List<int> list)
{
	foreach (int el in list)
	{
		Console.Write($" {el};");
	}
}

List<int> numbers = new List<int>() { 4, 3, 2, 1 };
optimizeBubbleSort(numbers);
printList(numbers);