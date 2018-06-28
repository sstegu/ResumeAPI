import { Component, Inject } from '@angular/core';
import { ApiService } from '../../api';

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
    public loading: boolean = true;

    constructor(api: ApiService) {
        this.error = false;
        api.GetResumeData("1").subscribe(result => {
            this.loading = false;
            if (result.ok) {
                this.candidate = result.json();
            } else {
                this.error = true;
            }

        }, error => {
            console.error(error)
            this.loading = false;
            this.error = true;
        });

    }

}


