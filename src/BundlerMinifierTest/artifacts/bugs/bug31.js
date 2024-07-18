function Bug31 (str) {
    if (BigInt(str) < BigInt("9223372036854775807")) {
        return true;
    }
};