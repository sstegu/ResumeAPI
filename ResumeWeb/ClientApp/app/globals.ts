﻿import { Injectable } from '@angular/core';
import { Subject } from 'rxjs/Subject';

@Injectable()
export class Globals {
    public companyGuid: string;
    public phone: string;
    public firstName: string;
    public lastName: string;
    public waiting: boolean;
}