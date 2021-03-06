﻿//
//  dg.MailQueue.net
//
//  Created by Daniel Cohen Gindi on 09/01/2014.
//  Copyright (c) 2014 Daniel Cohen Gindi. All rights reserved.
//
//  https://github.com/danielgindi/drunken-danger-zone
//
//  The MIT License (MIT)
//  
//  Copyright (c) 2014 Daniel Cohen Gindi (danielgindi@gmail.com)
//  
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in all
//  copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//  SOFTWARE. 
//  

using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.ServiceProcess;

namespace dg.MailQueue
{
    [RunInstaller(true)]
    public class MailQueueServiceInstaller : System.Configuration.Install.Installer
    {
        public MailQueueServiceInstaller()
        {
            using (ServiceProcessInstaller process = new ServiceProcessInstaller())
            {
                process.Account = ServiceAccount.NetworkService;

                using (ServiceInstaller serviceAdmin = new ServiceInstaller())
                {
                    serviceAdmin.StartType = ServiceStartMode.Automatic;
                    serviceAdmin.ServiceName = "mailQueue";
                    serviceAdmin.DisplayName = "dg.MailQueue.net";

                    Installers.Add(process);
                    Installers.Add(serviceAdmin);
                }
            }
        }
    }
}
