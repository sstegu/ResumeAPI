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
    public error: boolean;
    public errorMessage: string = "Well...that was unexpected.  Do I get the job??";

    constructor(api: ApiService, private globals: Globals) {
        this.error = false;
        Promise.resolve(null).then(() => this.globals.waiting$.next(true))
            .then(() => {
                api.GetResumeData("1").subscribe(result => {
                    if (result.ok) {
                        this.candidate = result.json();
                    } else {
                        this.error = true;
                    }

                }, error => {
                    console.error(error)
                    this.error = true;

                }, () => { });

            })
            .then(() => this.globals.waiting$.next(false));


    }

}


