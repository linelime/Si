from array import array



a = [1, 772, 36, 45, 5, 11, 222, 33, 44, 10]



def bubblesort(arr):
    for i in range(len(arr)):
        for j in range(len(arr)-1-i):
            if arr[j] > arr[j+1]:
                arr[j], arr[j+1] = arr[j+1], arr[j]
    return arr

print(bubblesort(a))