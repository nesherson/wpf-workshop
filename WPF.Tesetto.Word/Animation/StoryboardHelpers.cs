﻿using System.Windows;
using System;
using System.Windows.Media.Animation;

namespace WPF.Tesetto.Word
{
    public static class StoryboardHelpers
    {
        public static void AddSlideFromRight(this Storyboard storyboard, float seconds, double offset, float decelerationRatio = 0.9f)
        {
            var slideAnimation = new ThicknessAnimation()
            {
                Duration = TimeSpan.FromSeconds(seconds),
                From = new Thickness(offset, 0, -offset, 0),
                To = new Thickness(0),
                DecelerationRatio = decelerationRatio
            };
            Storyboard.SetTargetProperty(slideAnimation, new PropertyPath("Margin"));
            storyboard.Children.Add(slideAnimation);
        }

        public static void AddSlideToLeft(this Storyboard storyboard, float seconds, double offset, float decelerationRatio = 0.9f)
        {
            var slideAnimation = new ThicknessAnimation()
            {
                Duration = TimeSpan.FromSeconds(seconds),
                From = new Thickness(0),
                To = new Thickness(-offset, 0, offset, 0),
                DecelerationRatio = decelerationRatio
            };
            Storyboard.SetTargetProperty(slideAnimation, new PropertyPath("Margin"));
            storyboard.Children.Add(slideAnimation);
        }

        public static void AddFadeIn(this Storyboard storyboard, float seconds)
        {
            var slideAnimation = new DoubleAnimation()
            {
                Duration = TimeSpan.FromSeconds(seconds),
                From = 0,
                To = 1
            };
            Storyboard.SetTargetProperty(slideAnimation, new PropertyPath("Opacity"));
            storyboard.Children.Add(slideAnimation);
        }

        public static void AddFadeOut(this Storyboard storyboard, float seconds)
        {
            var slideAnimation = new DoubleAnimation()
            {
                Duration = TimeSpan.FromSeconds(seconds),
                From = 1,
                To = 0
            };
            Storyboard.SetTargetProperty(slideAnimation, new PropertyPath("Opacity"));
            storyboard.Children.Add(slideAnimation);
        }
    }
}
