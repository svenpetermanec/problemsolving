public int numDecodings(String s) {
        if (s.charAt(0) == '0')
            return 0;
        int doubleDigit = 0, singleDigit = 1;
        int len = s.length();
        int lastNum = s.charAt(len - 1) - '0';

        for (int i = len - 2; i >= 0; i--) {
            int currentNum = s.charAt(i) - '0';
            if (lastNum == 0) {
                if (currentNum == 0 || currentNum >= 3)
                    return 0;
                else {// currentNum can only be 1 or 2
                    lastNum = currentNum * 10;
                    doubleDigit = singleDigit;
                    singleDigit = 0;
                }
            } else if (lastNum >= 10 || currentNum > 2 || currentNum == 0) {
                lastNum = currentNum;
                singleDigit = singleDigit + doubleDigit;
                doubleDigit = 0;
                // all below is lastNum is 1-9
            } else if (currentNum == 1 || (currentNum == 2 && lastNum <= 6)) {
                int singlesFromDouble = doubleDigit;
                doubleDigit = singleDigit;
                singleDigit = singleDigit + singlesFromDouble;
                lastNum = currentNum;
                // last digit is 7 8 9 and current is 2
            } else {
                singleDigit = singleDigit + doubleDigit;
                doubleDigit = 0;
                lastNum = currentNum;
            }
        }
        return doubleDigit + singleDigit;
    }
