# DevOps

- it's a culture or a philosophy that is centered around bringing the Development and Operations teams together, to achieve quicker, more responsive software development/release cycle

- In order to achieve this quick turnaround, we use tools like CI/CD pipeline, code analysis tool, etc to automate quality monitoring and code integration/release

## CI
CI stands for Continuous Integration
- Continuous integration is a tool to seamlessly integrate newly written code into main codebase as smaller features are getting finished, so it can be steadily merged into main branch (of a sort)
- This allows us to test our code as they are being written and monitor our work progress
- we use build pipeline tools to automate this process, such that when there is a Pull Request, or a push to a branch, this pipeline _automagically_ gets triggered and runs a specified set of tasks.
- Common tasks done in CI pipeline are, unit testing, running code analysis tool, and compiling the app

## CD
### Continuous Delivery
Is a pipeline Build, publish (which generates the artifact) and in general make the app ready for deployment. Then it requires some kind manual push to the environment.

### Continuous Deployment
Continuous Delivery + it also deploys to an environment (like Test, QC)

All these pipelines use tools such as Github actions, Azure DevOps, AWS Codepipeline, Jenkins, etc. They use YAML files to run instructions from testing, building, publishing, and deploying.