array = {1,999,3, 422,31, 50, 99, 220, 300}

def bubble_sort(array):
    for i in range(len(array)):
        for j in range(len(array)-1):
            if array[j] > array[j+1]:
                array[j], array[j+1] = array[j+1], array[j]
    return array

bubble_sort(array)

print (array)