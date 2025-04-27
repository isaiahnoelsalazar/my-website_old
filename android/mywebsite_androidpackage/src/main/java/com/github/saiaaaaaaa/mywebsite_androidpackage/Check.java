package com.github.saiaaaaaaa.mywebsite_androidpackage;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;

public class Check {

    public static class Email {

        static List<String> validDomainNames = new ArrayList<>();
        static List<String> validDomainExtensions = new ArrayList<>();

        public static void addValidDomainName(String str){
            validDomainNames.add(str);
        }

        public static void addValidDomainExtensions(String str){
            validDomainExtensions.add(str);
        }

        public static boolean isValid(String str){
            try {
                String[] domain = str.split("@");
                String domainName = domain[1].split("\\.")[0];
                String domainExtension = domain[1].split("\\.")[1];
                return validDomainNames.contains(domainName) && validDomainExtensions.contains(domainExtension);
            } catch (Exception exception){
                return false;
            }
        }
    }

    public static boolean hasSymbols(String str){
        String symbols = "~`!@#$%^&*()_+-=[]{}\\|'\";:,.<>/?";
        for (int a = 0; a < str.length(); a++){
            for (int _c4 = 0; _c4 < symbols.length(); _c4++){
                if (str.charAt(a) == symbols.charAt(_c4)){
                    return true;
                }
            }
        }
        return false;
    }

    public static boolean hasNumbers(String str){
        String numbers = "0123456789";
        for (int a = 0; a < str.length(); a++){
            for (int b = 0; b < numbers.length(); b++){
                if (str.charAt(a) == numbers.charAt(b)){
                    return true;
                }
            }
        }
        return false;
    }

    public static boolean hasSpaces(String str){
        for (int a = 0; a < str.length(); a++){
            if (str.charAt(a) == ' '){
                return true;
            }
        }
        return false;
    }

    public static double howManySecondsLeft(Date now, Date until){
        return new Date(until.getTime() - now.getTime()).getTime() / 1000.0;
    }

    public static double howManyMinutesLeft(Date now, Date until){
        return new Date(until.getTime() - now.getTime()).getTime() / 60000.0;
    }

    public static double howManyHoursLeft(Date now, Date until){
        return new Date(until.getTime() - now.getTime()).getTime() / 60000.0 / 60.0;
    }

    public static double howManyDaysLeft(Date now, Date until){
        return new Date(until.getTime() - now.getTime()).getTime() / 60000.0 / 60.0 / 24.0;
    }
}
