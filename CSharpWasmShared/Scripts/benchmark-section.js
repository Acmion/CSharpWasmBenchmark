class BenchmarkCategorySection
{
	constructor(name, )
	{
        this.name = name;
	}

	render()
	{
        var template = 
        `
            <section class="indent">
                <h3 style="margin-top: 0">
                    ${this.name}
                </h3>

                <p>
                    An advanced CshtmlComponent that features <strong>attributes</strong>, <strong>child content</strong>,
                    <strong>named slots</strong>, <strong>typed slots</strong>, <strong>reference capturing</strong>,
                    <strong>head content injection</strong>, <strong>body content injection</strong>,
                    <strong>one-off content</strong> and <strong>model mutation</strong>.
                </p>

                <section class="indent">
                    <h4>
                        C# Code (AdvancedExampleComponent.cshtml.cs)
                    </h4>
                    <pre><code id="advanced-example-code"></code></pre>

                    <h4>
                        Cshtml Code (AdvancedExampleComponent.cshtml)
                    </h4>
                    <pre><code id="advanced-example-cshtml-code"></code></pre>

                    <h4>
                        Component Instantiation
                    </h4>
                    <pre><code id="advanced-example-instantiation-code"></code></pre>
                </section>

            </section>
        `;
	}
}