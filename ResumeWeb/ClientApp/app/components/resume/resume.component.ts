import { Component, Inject } from '@angular/core';
import { ApiService } from '../../api';
import { Globals } from '../../globals';

@Component({
    selector: 'resume',
    templateUrl: './resume.component.html',
    styleUrls: ['./resume.component.css'],
    providers: [ApiService]
})

export class ResumeComponent {
    public candidate: JSON;
    protected error: boolean;
    private wait: boolean;
    private errorMessage: string = "Well...that was unexpected.  Do I get the job??";

    constructor(api: ApiService, private globals: Globals) {
        this.error = false;
        this.globals.waiting = true;
        api.GetResumeData("1").subscribe(result => {
            if (result.ok) {
                this.candidate = result.json();
            }
        }, error => {
            console.error(error)
            this.error = true;
            this.globals.waiting = false;
        }, () => {
            this.globals.waiting = false;
        })




    }

}


