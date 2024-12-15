import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgbNavModule, NgbAccordionModule, NgbDropdownModule } from '@ng-bootstrap/ng-bootstrap';

// Swiper Slider
import { SlickCarouselModule } from 'ngx-slick-carousel';

// Counter
import { CountUpModule } from 'ngx-countup';

import { BreadcrumbsComponent } from './breadcrumbs/breadcrumbs.component';
import { ClientLogoComponent } from './landing/index/client-logo/client-logo.component';
import { ServicesComponent } from './landing/index/services/services.component';
import { AcademyComponent } from './landing/index/academy/academy.component';
import { CollectionComponent } from './landing/index/collection/collection.component';
import { CtaComponent } from './landing/index/cta/cta.component';
import { DesignedComponent } from './landing/index/designed/designed.component';
import { PlanComponent } from './landing/index/plan/plan.component';
import { FaqsComponent } from './landing/index/faqs/faqs.component';
import { ReviewComponent } from './landing/index/review/review.component';
import { CounterComponent } from './landing/index/counter/counter.component';
import { WorkProcessComponent } from './landing/index/work-process/work-process.component';
import { TeamComponent } from './landing/index/team/team.component';
import { ContactComponent } from './landing/index/contact/contact.component';
import { FooterComponent } from './landing/index/footer/footer.component';
import { ScrollspyDirective } from './scrollspy.directive';
import { LandingScrollspyDirective } from './landingscrollspy.directive';

// Job Landing 
import { BlogComponent } from './landing/job/blog/blog.component';
import { JobFooterComponent } from './landing/job/job-footer/job-footer.component';
import { ScrollToModule } from '@nicky-lenaers/ngx-scroll-to';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    BreadcrumbsComponent,
    ClientLogoComponent,
    ServicesComponent,
    AcademyComponent,
    CollectionComponent,
    CtaComponent,
    DesignedComponent,
    PlanComponent,
    FaqsComponent,
    ReviewComponent,
    CounterComponent,
    WorkProcessComponent,
    TeamComponent,
    ContactComponent,
    FooterComponent,
    BlogComponent,
    JobFooterComponent,
    ScrollspyDirective,
    LandingScrollspyDirective
  ],
  imports: [
    CommonModule,
    NgbNavModule,
    NgbAccordionModule,
    NgbDropdownModule,
    SlickCarouselModule,
    CountUpModule,
    FormsModule,
    ReactiveFormsModule,
    ScrollToModule.forRoot(),
  ],
  schemas:[CUSTOM_ELEMENTS_SCHEMA],
  exports: [BreadcrumbsComponent, ClientLogoComponent, ServicesComponent,AcademyComponent, CollectionComponent, CtaComponent, DesignedComponent, PlanComponent, FaqsComponent, ReviewComponent, CounterComponent, WorkProcessComponent, TeamComponent, ContactComponent, FooterComponent,ScrollspyDirective,
    LandingScrollspyDirective, BlogComponent, JobFooterComponent]
})
export class SharedModule { }
