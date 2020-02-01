import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  products: any[];
  category = '';
  search = '';
  constructor(private authService: AuthService) {}

  ngOnInit() {
    this.getProducts(this.category, this.search);
  }

  getProducts(category, search) {
    this.authService.getProducts(category, search).subscribe(
      (response: any) => {
        this.products = response;
        console.log(this.getProducts);
      },
      (error) => {
        console.log('no record found!');
      }
    );
  }
  selectCategory(value?) {
    this.category = value ? value : '';
    this.getProducts(this.category, this.search);
  }
}
