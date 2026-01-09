class SortStack {

    void sortStack(Stack<Integer> stack) {
        // Base case
        if (stack.isEmpty()) {
            return;
        }

        int top = stack.pop();

        // Sort remaining stack
        sortStack(stack);

        // Insert top element in sorted order
        insertInSortedOrder(stack, top);
    }

    void insertInSortedOrder(Stack<Integer> stack, int value) {
        // Base case
        if (stack.isEmpty() || stack.peek() <= value) {
            stack.push(value);
            return;
        }

        int temp = stack.pop();

        insertInSortedOrder(stack, value);

        stack.push(temp);
    }
}
