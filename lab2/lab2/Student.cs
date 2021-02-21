﻿using System;
using System.Collections.Generic;

namespace lab2
{
    public class Student
    {
        private string _name; //the name of the student
        public double averageMark; //the average student's mark 
        private bool _donater; //checks if the student is a contractor


        public Student(string name, int[] marks, bool donater) //students constructor :)
        {
            _name = name;
            averageMark = calculateAverage(marks);
            _donater = donater;
        }

        public static string getName(Student student)
        {
            return student._name;
        }

        public static double calculateAverage(int[] data) //this function was created to calculate the average value of marks :)
        {
            double result = 0;
            int sum = 0;
            foreach (int mark in data)
            {
                sum += mark;
            }
            result = Math.Round(Convert.ToDouble(sum) / data.Length, 3);

            return result;
        }

        public static void sortStudents(Student[] students) //this function is sorting student by their average mark :)
        {
            for (int i = 0; i < students.Length; i++)
            {   
                for (int j = 0; j < students.Length - 1; j++)
                {
                    if (students[j].averageMark < students[j + 1].averageMark)
                    {
                        swapStudents(ref students[j], ref students[j + 1]);
                    }
                }
            }
            
        }

        private static void swapStudents(ref Student student1, ref Student student2) //this function allows to swap 2 students (necessary for sortStudents function) :)
        {
            Student student;
            student = student1;
            student1 = student2;
            student2 = student;
        }

        private static string[,] toMatrix(Student[] students) //this function converts array of student to the matrix :)
        {
            string[,] matrix = new string[students.Length, 2];
            for (int i = 0; i < students.Length; i++)
            {
                matrix[i, 0] = students[i]._name;
                matrix[i, 1] = students[i].averageMark.ToString();
            }
            return matrix;
        }

        public static Student[] fromMatrix(string[,] matrix) //this function converts array of student to the matrix :)
        {
            List<Student> students = new List<Student>();
            for (int i = 0; i < matrix.Length/7; i++)
            {
                if (matrix[i, 6] == "FALSE")
                {
                    int[] temp = new int[5];
                    for (int j = 0; j < temp.Length; j++)
                    {
                        temp[j] = Convert.ToInt32(matrix[i, j + 1]);
                    }
                    students.Add(new Student(matrix[i, 0], temp, false));
                }
            }
            return students.ToArray();
        }

        public static Student[] findThoseWhoGetPaid(Student[] students) //this function shows, who gets money :)
        {
            sortStudents(students);
            List<Student> studentsWhoGetPaid = new List<Student>();
            int countStudentsWhoGetPaid = Convert.ToInt32(Math.Floor(0.4 * students.Length));
            for (int i = 0; i < countStudentsWhoGetPaid; i++)
            {
                studentsWhoGetPaid.Add(students[i]);
            }
            return studentsWhoGetPaid.ToArray();
        }

        public static double findMinMark(Student[] students) //this function returns the min avg mark that you need to have to get paid :)
        {
            return students[students.Length - 1].averageMark;
        }
    }
}