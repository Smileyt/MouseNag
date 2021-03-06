﻿using System;
using Machine.Specifications;
using Moq;
using MouseNag.InputMonitoring;
using MouseNag.Presentation;
using It = Machine.Specifications.It;

namespace MouseNag.Specs.MouseNagPresenterSpecs
{
    [Subject(typeof(MouseNagPresenter))]
    public class user_moves_mouse_then_presses_keyboard_then_moves_mouse
    {
        private static Mock<IInputSource> input;
        private static Mock<INag> annoyance;

        Establish context = () =>
        {
            annoyance = new Mock<INag>();
            input = new Mock<IInputSource>();
            new MouseNagPresenter(input.Object, annoyance.Object);
            input.Raise(i => i.MouseMoved += null, new EventArgs());
            input.Raise(i => i.KeyBoardKeyPressed += null, new EventArgs());
        };

        Because of = () =>
            input.Raise(i => i.MouseMoved += null, new EventArgs());

        It should_nag_once = () =>
            annoyance.Verify(a => a.Nag(), Times.Once());

    }
}
