import { Component, Inject, Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class ApiService {
    private http: Http;

    constructor(http: Http, @Inject("API_URL") private url: string) {
        this.http = http;
    }

    public GetCandidate(id: string): Observable<Response> {
        return this.GetData("/api/Candidates/" + id);
    }

    public GetResumeData(id: string): Observable<Response> {
        return this.GetData("/api/Candidates/" + id + "/Resume");
    }

    public GetCoverData(cguid: string): Observable<Response> {
        let guid: string = cguid != null ? cguid : 'default';
        return this.GetData("/api/CVContents/" + guid);
    }

    private GetData(path: string): Observable<Response> {
        return this.http.get(this.url + path);
    }
}