class QueueUsingStacks {
    Stack<Integer> inputStack = new Stack<>();
    Stack<Integer> outputStack = new Stack<>();

    // Enqueue operation
    void enqueue(int x) {
        inputStack.push(x);
    }

    int dequeue() {
        if (outputStack.isEmpty()) {
            while (!inputStack.isEmpty()) {
                outputStack.push(inputStack.pop());
            }
        }

        if (outputStack.isEmpty()) {
            return -1; // Queue is empty
        }

        return outputStack.pop();
    }
}
